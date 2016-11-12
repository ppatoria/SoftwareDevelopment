using System;
using System.Windows.Forms;
using System.IO;


// Declare a delegate type; instances refer to a method that
// takes an Int32 parameter and returns void.
internal delegate void Feedback(Int32 value);


public sealed class Program {
   public static void Main() {
      StaticDelegateDemo();
      InstanceDelegateDemo();
      ChainDelegateDemo1(new Program());
      ChainDelegateDemo2(new Program());
   }

   private static void StaticDelegateDemo() {
      Console.WriteLine("----- Static Delegate Demo -----");
      Counter(1, 3, null);
      Counter(1, 3, new Feedback(Program.FeedbackToConsole));
      Counter(1, 3, new Feedback(FeedbackToMsgBox)); // "Program." is optional
      Console.WriteLine();
   }

   private static void InstanceDelegateDemo() {
      Console.WriteLine("----- Instance Delegate Demo -----");
      Program p = new Program();
      Counter(1, 3, new Feedback(p.FeedbackToFile));

      Console.WriteLine();
   }

   private static void ChainDelegateDemo1(Program p) {
      Console.WriteLine("----- Chain Delegate Demo 1 -----");
      Feedback fb1 = new Feedback(FeedbackToConsole);
      Feedback fb2 = new Feedback(FeedbackToMsgBox);
      Feedback fb3 = new Feedback(p.FeedbackToFile);

      Feedback fbChain = null;
      fbChain = (Feedback) Delegate.Combine(fbChain, fb1);
      fbChain = (Feedback) Delegate.Combine(fbChain, fb2);
      fbChain = (Feedback) Delegate.Combine(fbChain, fb3);
      Counter(1, 2, fbChain);

      Console.WriteLine();
      fbChain = (Feedback)
         Delegate.Remove(fbChain, new Feedback(FeedbackToMsgBox));
      Counter(1, 2, fbChain);
   }

   private static void ChainDelegateDemo2(Program p) {
      Console.WriteLine("----- Chain Delegate Demo 2 -----");
      Feedback fb1 = new Feedback(FeedbackToConsole);
      Feedback fb2 = new Feedback(FeedbackToMsgBox);
      Feedback fb3 = new Feedback(p.FeedbackToFile);

      Feedback fbChain = null;
      fbChain += fb1;
      fbChain += fb2;
      fbChain += fb3;
      Counter(1, 2, fbChain);

      Console.WriteLine();
      fbChain -= new Feedback(FeedbackToMsgBox);
      Counter(1, 2, fbChain);
   }

   private static void Counter(Int32 from, Int32 to, Feedback fb) {
      for (Int32 val = from; val <= to; val++) {
         // If any callbacks are specified, call them
         if (fb != null)
            fb(val);
      }
   }

   private static void FeedbackToConsole(Int32 value) {
      Console.WriteLine("Item=" + value);
   }

   private static void FeedbackToMsgBox(Int32 value) {
      MessageBox.Show("Item=" + value);
   }

   private void FeedbackToFile(Int32 value) {
      using (StreamWriter sw = new StreamWriter("Status", true)) {
         sw.WriteLine("Item=" + value);
      }
   }
}

internal class Feedback : System.MulticastDelegate {
   // Constructor
   public Feedback(Object @object, IntPtr method);

   // Method with same prototype as specified by the source code
   public virtual void Invoke(Int32 value);

   // Methods allowing the callback to be called asynchronously
   public virtual IAsyncResult BeginInvoke(Int32 value,
      AsyncCallback callback, Object @object);
   public virtual void EndInvoke(IAsyncResult result);
}

public void Invoke(Int32 value) {
   Delegate[] delegateSet = _invocationList as Delegate[];
   if (delegateSet != null) {      
      foreach (Feedback d in delegateSet)   // This delegate's array indicates the delegates that should be called
          d(value);                         // Call each delegate
   } else {
                                            // This delegate identifies a single method to be called back Call the callback method on the specified target object.
      _methodPtr.Invoke(_target, value);
                                           // The preceding line is an approximation of the actual code. What really happens cannot be expressed in C#.
   }
}

public Int32 Invoke(Int32 value) {
   Int32 result;
   Delegate[] delegateSet = _invocationList as Delegate[];
   if (delegateSet != null) {
      // This delegate's array indicates the delegates that should be called
      foreach (Feedback d in delegateSet)
         result = d(value);   // Call each delegate
   } else {
      // This delegate identifies a single method to be called back
      // Call the callback method on the specified target object.
      result = _methodPtr.Invoke(_target, value);
      // The preceding line is an approximation of the actual code.
      // What really happens cannot be expressed in C#.
   }
   return result;
}
using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

internal sealed class MyForm : Form {

    static public void Main(){
        Application.Run(new MyForm());
    }

    private static Int32 Sum(Int32 n, CancellationToken cancelToken) {
        Int32 sum = 0;
        for (; n > 0; n--){
            cancelToken.ThrowIfCancellationRequested();
            checked{ sum += n; }            
        }
        return sum;
    }

    private readonly TaskScheduler m_syncContextTaskScheduler;
    public MyForm() {
        // Get a reference to a synchronization context task scheduler
        m_syncContextTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        Text = "Synchronization Context Task Scheduler Demo";
        Visible = true; Width = 600; Height = 100;
    }

    private CancellationTokenSource m_cts;

    protected override void OnMouseClick(MouseEventArgs e) {
        if (m_cts != null) { // An operation is in flight, cancel it
            m_cts.Cancel();
            m_cts = null;
        } else { // An operation is not in flight, start it
            Text = "Operation running";
            m_cts = new CancellationTokenSource();

            // This task uses the default task scheduler and executes on a thread pool thread
            Task<Int32> t = Task.Run(() => Sum(20000, m_cts.Token), m_cts.Token);

            // // These tasks use the sync context task scheduler and execute on the GUI thread
            // t.ContinueWith(task => Text = "Result: " + task.Result,
            //                CancellationToken.None, TaskContinuationOptions.OnlyOnRanToCompletion,
            //                m_syncContextTaskScheduler);

            // t.ContinueWith(task => Text = "Operation canceled",
            //                CancellationToken.None, TaskContinuationOptions.OnlyOnCanceled,
            //                m_syncContextTaskScheduler);

            // t.ContinueWith(task => Text = "Operation faulted",
            //                CancellationToken.None, TaskContinuationOptions.OnlyOnFaulted,
            //                m_syncContextTaskScheduler);

            // These tasks use thread pool task scheduler and execute on the GUI thread
            t.ContinueWith(task => Text = "Result: " + task.Result,
                           TaskContinuationOptions.OnlyOnRanToCompletion);

            t.ContinueWith(task => Text = "Operation canceled",
                           TaskContinuationOptions.OnlyOnCanceled);

            t.ContinueWith(task => Text = "Operation faulted",
                           TaskContinuationOptions.OnlyOnFaulted);
        }
        base.OnMouseClick(e);
    }
}
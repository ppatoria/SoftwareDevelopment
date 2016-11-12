public class Button {
    private class WeakDelegate {
	public WeakReference Target;
	public MethodInfo Method;
    }
    private List<WeakDelegate> clickSubscribers = new List<WeakDelegate>();
 
    public event EventHandler Click {
	add {
	    clickSubscribers.Add(new WeakDelegate {
		    Target = new WeakReference(value.Target),
		    Method = value.Method
		});
	}
	remove {
	    //...Implementation omitted for brevity
	}
    }
    public void FireClick() {
	List<WeakDelegate> toRemove = new List<WeakDelegate>();
	foreach (WeakDelegate subscriber in clickSubscribers) {
	    object target = subscriber.Target.Target;
	    if (target == null) {
		toRemove.Add(subscriber);
	    } else {
		subscriber.Method.Invoke(target, new object[] { this, EventArgs.Empty });
	    }
	}
	clickSubscribers.RemoveAll(toRemove);
    }
}
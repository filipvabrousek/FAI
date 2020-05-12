public class Program
{
	public static void Main() {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        bl.ProcessCompleted += bl_ProcessCompleted; // register with an event
        bl.StartProcess();
      }

    // event handler
    public static void bl_ProcessCompleted() {
        Console.WriteLine("Character chose his oponent.");
    }
}



public delegate void Notify();  // delegate
                    
public class ProcessBusinessLogic
{
    public event Notify ProcessCompleted; // event

    public void StartProcess()
    {

        OnProcessCompleted();
    }


    protected virtual void OnProcessCompleted()
    {
        ProcessCompleted?.Invoke();
    }
}

namespace CustomProgram
{
    // Interface: Defines the Method and Parameter that each ICommand needs to provide.
    public interface ICommand
    {
        // Execute the ICommand.
        public void Execute();

        // If True, ICommand executes for as long as the trigger is invoked.
        // If Flase, ICommand executes only once eachtime the trigger is invoked.
        public bool Continuous { get; }
    }
}

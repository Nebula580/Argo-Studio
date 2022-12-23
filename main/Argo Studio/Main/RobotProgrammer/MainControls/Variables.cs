namespace ArgoStudio.Main.RobotProgrammer.MainControls
{
    internal class Variables
    {
        public static readonly int[] variables_list = new int[16];

        public static void ResetAllVariablesToInitialValue()
        {
            for (int i = 0; i < variables_list.Length; i++)
            {
                variables_list[i] = 0;
            }
        }
    }
}
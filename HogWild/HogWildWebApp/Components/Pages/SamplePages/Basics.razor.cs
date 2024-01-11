namespace HogWildWebApp.Components.Pages.SamplePages
{
    public partial class Basics
    {
        #region Privates
        //  used to display my name
        private string? myName;
        // the odd or even value
        private int oddEvenValue;
        #endregion

        #region Methods
        // Generates a random number between 0 and 25 using the Random class
        // Checks if the generated number is even
        // Sets the 'myName' variable to a message if even, or to null if odd
        private void RandomValue()
        {
            // Create an instance of the Random class to generate random numbers.
            Random rnd = new Random();

            // Generate a random integer between 0 (inclusive) and 25 (exclusive).
            oddEvenValue = rnd.Next(0, 25);

            // Check if the generated number is even.
            if (oddEvenValue % 2 == 0)
            {
                // If the number is even, construct a message with the number and assign it to 'myName'.
                myName = $"James is even {oddEvenValue}";
            }
            else
            {
                // If the number is odd, set 'myName' to null.
                myName = null;
            }

            // Trigger an asynchronous update of the component's state to reflect the changes made.
            InvokeAsync(StateHasChanged);
        }
        #endregion

    }
}

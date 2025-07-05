public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create an array of doubles with the specified length
        // Step 2: Use a loop to fill the array with multiples
        // Step 3: For each position i (0 to length-1), calculate number * (i+1)
        // Step 4: Store each multiple in the array at position i
        // Step 5: Return the completed array

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Calculate the split point - where to cut the list
        //         Split point = data.Count - amount (elements from the end to move to front)
        // Step 2: Get the elements that need to move to the front (last 'amount' elements)
        // Step 3: Get the elements that stay but move to the back (first part of the list)
        // Step 4: Clear the original list
        // Step 5: Add the elements that go to the front first
        // Step 6: Add the elements that go to the back second

        int splitPoint = data.Count - amount;

        // Get the last 'amount' elements that will move to the front
        List<int> elementsToFront = data.GetRange(splitPoint, amount);

        // Get the first part that will move to the back
        List<int> elementsToBack = data.GetRange(0, splitPoint);

        // Clear the original list and rebuild it in the new order
        data.Clear();
        data.AddRange(elementsToFront);
        data.AddRange(elementsToBack);
    }
}

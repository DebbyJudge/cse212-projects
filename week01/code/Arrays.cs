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
        // Plan:
        // Step 1: Create an array that can store 'length' number of values.
        // Step 2: Use a loop that runs from index 0 up to length - 1.
        // Step 3: For each position in the array, calculate the multiple of the number.
        // Step 4: The first value should be number * 1, the second value number * 2, etc.
        // Step 5: Store each calculated value in the array at the current index.
        // Step 6: After the loop finishes, return the completed array.

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
        // Plan:
        // Step 1: Determine where the list should be split. This will be data.Count - amount.
        // Step 2: Take the last 'amount' elements from the list.
        // Step 3: Take the first part of the list before the split.
        // Step 4: Clear the original list.
        // Step 5: Add the last part of the list first.
        // Step 6: Add the beginning part of the list after it.
        // Step 7: The list will now be rotated to the right.

        int splitIndex = data.Count - amount;

        List<int> endPart = data.GetRange(splitIndex, amount);
        List<int> startPart = data.GetRange(0, splitIndex);

        data.Clear();

        data.AddRange(endPart);
        data.AddRange(startPart);
    }
}
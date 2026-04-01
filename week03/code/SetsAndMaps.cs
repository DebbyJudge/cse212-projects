using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        // Plan:
        // 1. Create a HashSet to store all words for quick lookup (O(1))
        // 2. Loop through each word in the array
        // 3. Reverse the word (e.g., "am" -> "ma")
        // 4. Check:
        //    - reversed word exists in the set
        //    - word is not equal to its reverse (ignore "aa")
        // 5. Store result as "word & reversed"
        // 6. Use another set to avoid duplicate pairs
        // 7. Return results as array

        var wordSet = new HashSet<string>(words);
        var result = new HashSet<string>();

        foreach (var word in words)
        {
            var reversed = new string(word.Reverse().ToArray());

            if (word != reversed && wordSet.Contains(reversed))
            {
                // To avoid duplicates like "am & ma" and "ma & am"
                var pair = word.CompareTo(reversed) < 0
                    ? $"{word} & {reversed}"
                    : $"{reversed} & {word}";

                result.Add(pair);
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            // Plan:
            // 1. Get degree from column 4 (index 3)
            // 2. Check if degree already exists in dictionary
            // 3. If yes, increment count
            // 4. If no, add it with count 1

            var degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if two words are anagrams
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Plan:
        // 1. Remove spaces and convert to lowercase
        // 2. If lengths differ, return false
        // 3. Use dictionary to count letters in word1
        // 4. Loop through word2 and decrease counts
        // 5. If any count goes below 0, return false
        // 6. If all counts match, return true

        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        var letterCount = new Dictionary<char, int>();

        foreach (var c in word1)
        {
            if (letterCount.ContainsKey(c))
                letterCount[c]++;
            else
                letterCount[c] = 1;
        }

        foreach (var c in word2)
        {
            if (!letterCount.ContainsKey(c))
                return false;

            letterCount[c]--;

            if (letterCount[c] < 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Earthquake (SKIPPED for now)
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // Skipped (optional / extra credit)
        return [];
    }
}
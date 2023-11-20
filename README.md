# AbstractInterp
Abstract Interpolation

## Compares Chat GPT 3.5 vs 4.0


## Chat GPT 3.5

Sure! Here's a linear interpolation function that takes the inputs as described:

```csharp
public static Dictionary<int, double> LinearInterpolation(Dictionary<int, double> inputs, List<int> interpXPoints)
{
    Dictionary<int, double> interpolatedValues = new Dictionary<int, double>();
    
    for (int i = 0; i < interpXPoints.Count; i++)
    {
        int x = interpXPoints[i];
        
        if (inputs.ContainsKey(x))
        {
            // If exact x value is present in the inputs, use the corresponding y value
            interpolatedValues.Add(x, inputs[x]);
        }
        else
        {
            // Find the two nearest x values in the inputs
            int lowerX = inputs.Keys.LastOrDefault(key => key < x);
            int upperX = inputs.Keys.FirstOrDefault(key => key > x);
            
            // Check if lower and upper x values exist
            if (lowerX == 0 || upperX == 0)
                continue;
            
            // Perform linear interpolation
            double deltaX = upperX - lowerX;
            double deltaY = inputs[upperX] - inputs[lowerX];
            double interpY = inputs[lowerX] + ((x - lowerX) * (deltaY / deltaX));
            
            interpolatedValues.Add(x, interpY);
        }
    }
    
    return interpolatedValues;
}
```

Here's an example usage:

```csharp
Dictionary<int, double> inputs = new Dictionary<int, double>
{
    { 0, 0.0 },
    { 10, 10.0 },
    { 20, 20.0 }
};

List<int> interpXPoints = new List<int> { 5, 15, 25 };

Dictionary<int, double> interpolatedValues = LinearInterpolation(inputs, interpXPoints);

foreach (var kvp in interpolatedValues)
{
    Console.WriteLine($"Interpolated value at x = {kvp.Key}: y = {kvp.Value}");
}
```

Output:
```
Interpolated value at x = 5: y = 5
Interpolated value at x = 15: y = 15
Interpolated value at x = 25: y = 25
```

Note that in this example, the interpolation function simply returns the existing y values for the nearest x values, as there are no gaps in the provided inputs for which interpolation is required.

## Chat GPT 4.0

Here is a C# function that uses linear interpolation for given Dictionary<int, double> data points and a List<int> of x-points for which we interpolate:

```csharp
public static Dictionary<int, double> LinearInterpolate(Dictionary<int, double> points, List<int> interpX)
{
    SortedDictionary<int, double> sortedPoints = new SortedDictionary<int, double>(points);
    Dictionary<int, double> interpPoints = new Dictionary<int, double>();

    int prevX = sortedPoints.First().Key, nextX = sortedPoints.First().Key;
    double prevY = sortedPoints.First().Value, nextY = sortedPoints.First().Value;

    foreach (var x in interpX)
    {
        if (x < prevX)
        {
            interpPoints.Add(x, prevY);
        }
        else if (x > nextX)
        {
            while (x > nextX && sortedPoints.Count > 0)
            {
                prevX = nextX;
                prevY = nextY;
                sortedPoints.Remove(prevX);
                if (sortedPoints.Count > 0)
                {
                    nextX = sortedPoints.First().Key;
                    nextY = sortedPoints.First().Value;
                }
                else
                {
                    nextX = x;
                    nextY = prevY;
                }
            }
            double interpolatedY = (x - prevX) * (nextY - prevY) / (nextX - prevX) + prevY;
            interpPoints.Add(x, interpolatedY);
        }
        else
        {
            interpPoints.Add(x, prevY);
        }
    }

    return interpPoints;
}
```
This function calculates line segment parameters between source points and uses them to calculate y for each x from interpX list. The SortedDictionary is used to handle points that are not sorted in the input.

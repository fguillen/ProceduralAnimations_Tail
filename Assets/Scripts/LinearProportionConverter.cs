/*
Convert from one magnitude to another.

Example:

  LinearProportionConverter collisionToVolume = new LinearProportionConverter(soundVolumeLimits.x, soundVolumeLimits.y, collisionMagnitudeLimits.x, collisionMagnitudeLimits.y);
  float volume = collisionToVolume.CalculateDimension1Value(collisionMagnitude);
  audioSource.PlayOneShot(clip, volume);
*/

public class LinearProportionConverter
{
    float dimension1Min;
    float dimension1Max;
    float dimension2Min;
    float dimension2Max;

    public LinearProportionConverter(float dimension1Min, float dimension1Max, float dimension2Min, float dimension2Max)
    {
        this.dimension1Min = dimension1Min;
        this.dimension1Max = dimension1Max;
        this.dimension2Min = dimension2Min;
        this.dimension2Max = dimension2Max;
    }

    public float CalculateDimension1Value(float dimension2Value)
    {
        var a = dimension2Min;
        var b = dimension2Max;
        var c = dimension1Min;
        var d = dimension1Max;
        var e = dimension2Value;

        var result = c + (((e - a) * (d - c)) / (b - a));

        return result;
    }

    public float CalculateDimension2Value(float dimension1Value)
    {
        var a = dimension1Min;
        var b = dimension1Max;
        var c = dimension2Min;
        var d = dimension2Max;
        var e = dimension1Value;

        var result = c + (((e - a) * (d - c)) / (b - a));

        return result;
    }
}
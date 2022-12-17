namespace J1P2_PRO_TextAdventure.Environment;

internal abstract class LivingEntity
{
    private readonly float height;
    private float weight;

    public float BMI
    {
        get
        {
            double lengthSquared = Math.Pow(height, 2);
            double bmi = Math.Round(weight / lengthSquared, 1);
            return (float)bmi;
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="_maxHp">set's the max HP, value needs to be above 0</param>
    /// <exception cref="ArgumentOutOfRangeException" />
    public LivingEntity(float _weight, float _height)
    {
        weight = _weight;
        height = _height;
    }

    protected void GainWeight(float _weight)
    {
        weight += _weight;
    }
}

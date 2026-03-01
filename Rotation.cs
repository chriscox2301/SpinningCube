namespace RotatingCube;

public static class Rotation
{
	// Roteer punt om de X-as met de hoek theta (in radialen)
	public static Vec3 RotateX(Vec3 v, float theta)
	{
		return new Vec3(
			v.X,
			v.Y * MathF.Cos(theta) - v.Z * MathF.Sin(theta),
			v.Y * MathF.Sin(theta) + v.Z * MathF.Cos(theta)
		);
	}

	// Roteer punt om de Y-as met de hoek theta (in radialen)
	public static Vec3 RotateY(Vec3 v, float theta)
	{
		return new Vec3(
			v.X * MathF.Cos(theta) + v.Z * MathF.Sin(theta),
			v.Y,
			-v.X * MathF.Sin(theta) + v.Z * MathF.Cos(theta)
		);
	}
}

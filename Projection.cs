namespace RotatingCube;

public static class Projection
{
	// Projecteer een 3D punt naar 2D schermcoordinaten
	// fov = field of view factor (bijv. 200)
	// cameraZ = afstand camera tot oorsprong (bijv. 5)
	public static (int screenX, int screenY) Project(Vec3 v, int screenWidth, int screenHeight, float fov = 200f, float cameraZ = 5f)
	{
		float z = v.Z + cameraZ; // verschuift zodat Z altijd positief is
		float x = (v.X / z) * fov + screenWidth / 2f;
		float y = (v.Y / z) * fov * 0.5f + screenHeight / 2f; // *0.5f corrigeert voor terminal verhouding
		return ((int)x, (int)y);
	}
}

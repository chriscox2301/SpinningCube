using RotatingCube;

// Instellingen
const int width = 80;
const int height = 40;
const float rotationSpeed = 0.03f; // Radialen per frame

Console.CursorVisible = false;
Console.Clear();

var renderer = new Renderer(width, height);
float angleX = 0f;
float angleY = 0f;

while (true)
{
	renderer.Clear();

	// Roteer alle hoekpunten en projecteer naar 2D
	var projected = new (int x, int y)[Cube.Vertices.Length];
	for (int i = 0; i < Cube.Vertices.Length; i++)
	{
		Vec3 v = Cube.Vertices[i];
		v = Rotation.RotateX(v, angleX);
		v = Rotation.RotateY(v, angleY);
		projected[i] = Projection.Project(v, width, height);
	}

	// Teken alle ribben
	foreach (var (a, b) in Cube.Edges)
	{
		renderer.Drawline(
			projected[a].x, projected[a].y,
			projected[b].x, projected[b].y
		);
	}

	renderer.Flush();

	angleX += rotationSpeed * 0.7f; // Iets langzamer om X
	angleY += rotationSpeed;
	Thread.Sleep(33); // ~30 fps
}

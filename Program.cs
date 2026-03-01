using RotatingCube;

// Instellingen
int width = Console.WindowWidth;
int height = Console.WindowHeight - 1; // -1 voorkomt automatische scroll
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
	var rotated  = new Vec3[Cube.Vertices.Length];
	var projected = new (int x, int y)[Cube.Vertices.Length];
	for (int i = 0; i < Cube.Vertices.Length; i++)
	{
		Vec3 v = Cube.Vertices[i];
		v = Rotation.RotateX(v, angleX);
		v = Rotation.RotateY(v, angleY);
		rotated[i]   = v;
		projected[i] = Projection.Project(v, width, height);
	}

	// Teken alle ribben met diepte-karakter op basis van gemiddelde Z
	foreach (var (a, b) in Cube.Edges)
	{
		float avgZ = (rotated[a].Z + rotated[b].Z) / 2f;
		float t = (avgZ + 1f) / 2f; // 0 = voor (dichtbij), 1 = achter (ver weg)
		char symbol = t < 0.25f ? '#'
		            : t < 0.50f ? '+'
		            : t < 0.75f ? '-'
		            :              '.';
		renderer.Drawline(
			projected[a].x, projected[a].y,
			projected[b].x, projected[b].y,
			symbol
		);
	}

	renderer.Flush();

	angleX += rotationSpeed * 0.7f; // Iets langzamer om X
	angleY += rotationSpeed;
	Thread.Sleep(33); // ~30 fps
}

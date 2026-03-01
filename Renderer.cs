namespace RotatingCube;

public class Renderer(int width, int height)
{
	private readonly char[] _buffer = new char[width * height];
	private readonly int _width = width;
	private readonly int _height = height;

	public void Clear() => Array.Fill(_buffer, ' ');

	public void DrawPixel(int x, int y, char c = '#')
	{
		if (x >= 0 && x < _width && y >= 0 && y < _height)
			_buffer[y * _width + x] = c;
	}

	// Bresenham lijn-algoritme: teken een lijn van (x0,y0) naar (x1,y1)
	public void Drawline(int x0, int y0, int x1, int y1, char c = '#')
	{
		int dx = Math.Abs(x1 - x0), dy = Math.Abs(y1 - y0);
		int sx = x0 < x1 ? 1 : -1, sy = y0 < y1 ? 1 : -1;
		int err = dx - dy;

		while (true)
		{
			DrawPixel(x0, y0, c);
			if (x0 == x1 && y0 == y1) break;
			int e2 = 2 * err;
			if (e2 > -dy) { err -= dy; x0 += sx; }
			if (e2 < dx) { err += dx; y0 += sy; }
		}
	}

	// Schrijf de buffer naar de console (cursor terug naar (0,0))
	public void Flush()
	{
		Console.SetCursorPosition(0,0);
		var sb = new System.Text.StringBuilder(_width * _height + _height);
		for (int y = 0; y < _height; y++)
		{
			sb.Append(_buffer, y * _width, _width);
			if (y < _height - 1) sb.Append('\n');
		}
		Console.Write(sb);
	}
}

namespace RotatingCube;

public static class Cube
{
    // 8 hoekpunten van een eenheidskubus (zijde = 2, gecentreerd op oorsprong)
    public static readonly Vec3[] Vertices =
    [
        new(-1, -1, -1), // 0: links-onder-voor
        new( 1, -1, -1), // 1: rechts-onder-voor
        new( 1,  1, -1), // 2: rechts-boven-voor
        new(-1,  1, -1), // 3: links-boven-voor
        new(-1, -1,  1), // 4: links-onder-achter
        new( 1, -1,  1), // 5: rechts-onder-achter
        new( 1,  1,  1), // 6: rechts-boven-achter
        new(-1,  1,  1), // 7: links-boven-achter
    ];

    // 12 ribben als paren van vertex-indices
    public static readonly (int, int)[] Edges =
    [
        (0, 1), (1, 2), (2, 3), (3, 0), // voorvlak
        (4, 5), (5, 6), (6, 7), (7, 4), // achtervlak
        (0, 4), (1, 5), (2, 6), (3, 7), // verbindingsribben
    ];
}

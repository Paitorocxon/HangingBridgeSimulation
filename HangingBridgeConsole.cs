using System;

public class HangBridgeSimulation
{
    private const float Gravity = 9.8f; // Gravitationskonstante
    private const float TensionForceFactor = 0.5f; // Faktor für die Zugkraft in den Seilen

    private float bridgeLength; // Länge der Brücke
    private float bridgeHeight; // Höhe der Brücke
    private float bridgeMassPerUnitLength; // Masse pro Einheitslänge der Brücke

    private float[] cableForces; // Kräfte in den Seilen

    public HangBridgeSimulation(float bridgeLength, float bridgeHeight, float bridgeMassPerUnitLength)
    {
        this.bridgeLength = bridgeLength;
        this.bridgeHeight = bridgeHeight;
        this.bridgeMassPerUnitLength = bridgeMassPerUnitLength;

        cableForces = new float[3]; // Annahme: Es gibt 3 Seile
    }

    public void Simulate()
    {
        // Berechnung der Kräfte in den Seilen

        // Gewichtskraft
        float bridgeWeight = bridgeMassPerUnitLength * bridgeLength * Gravity;

        // Zugkraft in den Seilen
        float tensionForce = TensionForceFactor * bridgeWeight;

        // Verteilung der Zugkräfte auf die Seile
        float halfBridgeLength = bridgeLength / 2;
        cableForces[0] = tensionForce * (bridgeHeight / halfBridgeLength);
        cableForces[1] = tensionForce * ((halfBridgeLength - bridgeHeight) / halfBridgeLength);
        cableForces[2] = tensionForce;

        // Ausgabe der Ergebnisse
        Console.WriteLine("Simulation results:");
        Console.WriteLine("Bridge length: " + bridgeLength);
        Console.WriteLine("Bridge height: " + bridgeHeight);
        Console.WriteLine("Bridge mass per unit length: " + bridgeMassPerUnitLength);
        Console.WriteLine("Cable forces: ");
        Console.WriteLine("Cable 1: " + cableForces[0]);
        Console.WriteLine("Cable 2: " + cableForces[1]);
        Console.WriteLine("Cable 3: " + cableForces[2]);
    }
}

public class Program
{
    public static void Main()
    {
        // Beispielaufruf der Hängebrücken-Simulation
        float bridgeLength = 20.0f; // Länge der Brücke in Metern
        float bridgeHeight = 5.0f; // Höhe der Brücke in Metern
        float bridgeMassPerUnitLength = 100.0f; // Masse pro Einheitslänge der Brücke in kg/m

        HangBridgeSimulation simulation = new HangBridgeSimulation(bridgeLength, bridgeHeight, bridgeMassPerUnitLength);
        simulation.Simulate();
    }
}

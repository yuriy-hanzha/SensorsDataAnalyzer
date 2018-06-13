namespace SensorsDataAnalyzer.Processing
{
    /// <summary>
    /// List of different places, where a smartphone can be while motion of a person
    /// </summary>
    public enum SmartphonePositions
    {
        HandHeld, // holding smartphone in one hand
        HandHeldUsing, // holding smartphone in front of the face
        TrousersFrontPocket, // in trousers front pocket
        TrousersBackPocket, // in trousers back pocket
        Backpack, // in backpack
        Handbag, // in handbag
        Not_Found,
    }
}

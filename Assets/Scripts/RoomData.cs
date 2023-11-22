public static class RoomData
{
    static float length;
    static float width;
    static float height;
    
    public static float GetLength()
    {
        return length;
    }
    public static float GetWidth()
    {
        return width;
    }
    public static float GetHeight()
    {
        return height;
    }
    public static void SetLength(float l)
    {
         length = l;
    }
    public static void SetWidth(float w)
    {
        width = w;
    }
    public static void SetHeight(float h)
    {
        height = h;
    }
}

[System.Serializable]
public class SaveObject
{
    [System.Serializable]
    public struct Friends
    {
        public bool akane;
        public bool mariya;
        public bool rikako;
        public bool kanari;
    }

    public bool introCutscene;
    public Friends friends;
    public bool[] pandas = new bool[5];
    public int pandaCount;
    public bool exercise;
}

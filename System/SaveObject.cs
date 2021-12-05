[System.Serializable]
public class SaveObject
{

    public string playerName = "Player" ;

    [System.Serializable]
    public struct Friends
    {
        public bool akane;
        public bool mariya;
        public bool rikako;
        public bool kanari;
        public bool iroha;
    }

    public bool introCutscene;
    public Friends friends;
    public bool[] pandas = new bool[6];
    
    public bool exercise;
    public bool cafe;
    public bool work;
    public bool groceries;
    public bool paint;

    public int pandaCount = 0;
    public int friendCount = 0;
}

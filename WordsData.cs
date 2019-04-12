[System.Serializable]
public class WordsData
{
    public WordsDataItem[] items;
}
[System.Serializable]
public class WordsDataItem
{
    public string word;//单词
    public string phonetic;//音标
    public string definition;//单词释义（英文），每行一个释义
    public string translation;//单词释义（中文），每行一个释义
    public string pos;//词语位置，用 "/" 分割不同位置
    public string collins;//柯林斯星级
    public string oxford;//是否是牛津三千核心词汇
    public string tag;//标签
    public string bnc;//英国国家语料库词频顺序
    public string frq;//当代语料库词频顺序
    public string exchange;//时态复数等变换
}
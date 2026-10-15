public class Solution {
    public bool IsAnagram(string s, string t) {
        Dictionary<char, int> myDic = new();
        if(s.Length != t.Length)
            return false;
        for(int idx = 0; idx < s.Length; idx++){
            if(myDic.ContainsKey(s[idx]))
                myDic[s[idx]] += 1;
            else
                myDic[s[idx]] = 1;
            if(myDic.ContainsKey(t[idx]))
                myDic[t[idx]] += -1;
            else
                myDic[t[idx]] = -1;
        }
        foreach(int val in myDic.Values)
            if(val != 0)
                return false;
        return true;
    }
}
public class Solution {
    public bool IsAnagram(string s, string t) {
        if(s.Length != t.Length)
            return false;
        int[] letterCpt = new int[26];

        for (int i = 0; i < s.Length; i++) {
            letterCpt[s[i] - 'a']++;
            letterCpt[t[i] - 'a']--;
        }

        foreach(int val in letterCpt)
            if(val != 0)
                return false;
        return true;
    }
}
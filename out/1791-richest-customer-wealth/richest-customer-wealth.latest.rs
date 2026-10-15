impl Solution {
    pub fn maximum_wealth(accounts: Vec<Vec<i32>>) -> i32 {
        //accounts.iter().map(|a| a.iter().sum()).max().unwrap()
        let mut result: i32 = 0;
        for i in &accounts {
            let mut wealth: i32 = 0;
            for j in i { wealth += j; }
            result = if result > wealth { result } else { wealth };
        }
        result
    }
}
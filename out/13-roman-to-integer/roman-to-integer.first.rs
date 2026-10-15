// TODO: replace with actual function signature from problem

impl Solution {
    fn symbol_to_value(symbol: char) -> i32 {
        let mut result: i32;
        match symbol {
            'I' => result = 1,
            'V' => result = 5,
            'X' => result = 10,
            'L' => result = 50,
            'C' => result = 100,
            'D' => result = 500,
            'M' => result = 1000,
            _ => todo!(),
        }
        result
    }

    pub fn roman_to_int(s: String) -> i32 {
        let mut index = s.len()-1;
        let s = s.chars();
        let mut result = 0;
        let mut ref_value = 0;
        for symbol in s.rev() {
            let value = Solution::symbol_to_value(symbol);

            if value >= ref_value {
                ref_value = value;
                result += value;
            }
            else{
                result -= value;
            }
        }
        result
    }
}

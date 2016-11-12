//{1, 2, 3, 2, 2, 2, 5, 4, 2}
int getMajority_2(int[] numbers) {
    int result = numbers[0];
    int times = 1;
    for(int i = 1; i < numbers.length; ++i) {
        if(times == 0) {
            result = numbers[i];
            times = 1;
        }
        else if(numbers[i] == result)
            times++;
        else
            times--;
    }

    if(!checkMajorityExistence(numbers, result))
        throw new IllegalArgumentException("No majority exisits.");

    return result;
}
r 1
t 1

i 1
t 0 

i 2
r 3
t 1

i 3
t 0

i 4
r 2
t 1

i 5
t 0

i 6 
r 5
t 1

i 7
t 0

i 8
r 2
t 1


int getMajority_1(int[] numbers) {
    int length = numbers.length;
    int middle = length >> 1;
    int start = 0;
    int end = length - 1;

    int index = partition(numbers, start, end);
    while(index != middle) {
        if(index > middle) {
            end = index - 1;
            index = partition(numbers, start, end);
        }
        else {
            start = index + 1;
            index = partition(numbers, start, end);
        }
    }

    int result = numbers[middle];
    if(!checkMajorityExistence(numbers, result))
        throw new IllegalArgumentException("No majority exisits.");

    return result;
}

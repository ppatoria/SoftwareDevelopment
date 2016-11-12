
void test::func()
{
}

void test::func1()
{
    func();
}

int main()
{
    test t;
    t.func();
    t.func1();
}

using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Array.BinarySearch (T[],  T, Generic IComparer) 
/// </summary>
public class ArrayBinarySearch5
{
    const int c_MaxValue = 10;
    const int c_MinValue = 0;
    public static int Main()
    {
        ArrayBinarySearch5 ArrayBinarySearch5 = new ArrayBinarySearch5();

        TestLibrary.TestFramework.BeginTestCase("ArrayBinarySearch5");
        if (ArrayBinarySearch5.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }

    public bool RunTests()
    {
        bool retVal = true;

        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        retVal = PosTest3() && retVal;
        TestLibrary.TestFramework.LogInformation("[Negative]");
        retVal = NegTest1() && retVal;
        retVal = NegTest2() && retVal;
        return retVal;
    }

    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest1: Searches a range of elements in a one-dimensional sorted Array for a int type value, using the default IComparer implement.");

        try
        {

            int[] myArray = new int[c_MaxValue];
            int generator = 0;
            for (int i = 0; i < c_MaxValue; i++)
            {
                generator = TestLibrary.Generator.GetInt32();
                myArray.SetValue(generator, i);
            }
            int searchValue = (int)myArray.GetValue(c_MaxValue - 1);
            //sort the array
            Array.Sort(myArray);
            int returnvalue = Array.BinarySearch<int>(myArray,  searchValue, null);
            if (returnvalue >= 0)
            {
                if (searchValue != (int)myArray.GetValue(returnvalue))
                {
                    TestLibrary.TestFramework.LogError("001", "Search falure .");
                    retVal = false;
                }
            }
            else
            {
                TestLibrary.TestFramework.LogError("002", "Postive condition is error.");
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("003", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest2: Searches a range of elements in a one-dimensional sorted Array for a string type value, using the default IComparer implement.");

        try
        {
            string[] myArray = new string[c_MaxValue];
            string generator = string.Empty;
            for (int i = 0; i < c_MaxValue; i++)
            {
                generator = TestLibrary.Generator.GetString(true, c_MinValue, c_MaxValue);
                myArray.SetValue(generator, i);
            }
            string expectedstring = myArray.GetValue(c_MaxValue - 1).ToString();

            //sort the array
            Array.Sort(myArray);
            string searchValue = expectedstring;
            int returnvalue = Array.BinarySearch<string>(myArray,  searchValue, null);
            if (returnvalue >= 0)
            {
                if (0 != expectedstring.CompareTo(myArray.GetValue(returnvalue).ToString()))
                {
                    TestLibrary.TestFramework.LogError("004", "Search falure .");
                    retVal = false;
                }
            }
            else
            {
                TestLibrary.TestFramework.LogError("005", "Postive condition is error.");
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("006", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool PosTest3()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("PosTest3: Searches a range of elements in a one-dimensional sorted Array for a customer define type , using the default IComparer implement.");

        try
        {
            Temperature<int>[] myArray = new Temperature<int>[c_MaxValue];
            Temperature<int> generator = null;
            for (int i = 0; i < c_MaxValue; i++)
            {
                generator = new Temperature<int>();
                generator.Value = i * 4;
                myArray.SetValue(generator, i);
            }
            Temperature<int> expected = myArray.GetValue(c_MaxValue - 1) as Temperature<int>;
            IComparer<Temperature<int>> iComparableImpl = myArray.GetValue(c_MaxValue - 1) as Temperature<Temperature<int>>;
            //sort the array
            Array.Sort<Temperature<int>>(myArray, (IComparer<Temperature<int>>)iComparableImpl);
            int returnvalue = Array.BinarySearch<Temperature<int>>(myArray,  myArray.GetValue(c_MaxValue - 1) as Temperature<int>, iComparableImpl as IComparer<Temperature<int>>);
            if (returnvalue >= 0)
            {
                if (!expected.Equals(myArray.GetValue(returnvalue)))
                {
                    TestLibrary.TestFramework.LogError("007", "Search falure .");
                    retVal = false;
                }
            }
            else
            {
                TestLibrary.TestFramework.LogError("008", "Postive condition is error.");
                retVal = false;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("009", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest1()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest1: array is a null reference.");

        try
        {
            Temperature<int>[] myArray = new Temperature<int>[c_MaxValue];
            Temperature<int> generator = null;
            for (int i = 0; i < c_MaxValue; i++)
            {
                generator = new Temperature<int>();
                generator.Value = i * 4;
                myArray.SetValue(generator, i);
            }
            IComparer<int> iComparableImpl = myArray.GetValue(c_MaxValue - 1) as Temperature<int>;
            myArray = null;
            int returnvalue = Array.BinarySearch<Temperature<int>>(myArray,  iComparableImpl as Temperature<int>, iComparableImpl as IComparer<Temperature<int>>);

            TestLibrary.TestFramework.LogError("010", "array is a null reference.");
            retVal = false;
        }
        catch (ArgumentNullException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("011", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }

    
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong
    public bool NegTest2()
    {
        bool retVal = true;

        TestLibrary.TestFramework.BeginScenario("NegTest2: comparer is a null reference , " +
            "\nvalue does not implement the IComparable interface, " +
            "\nand the search encounters an element that does not \nimplement the IComparable interface.");

        try
        {
            TestClass<int>[] myArray = new TestClass<int>[c_MaxValue];
            TestClass<int> generator = null;
            for (int i = 0; i < c_MaxValue; i++)
            {
                generator = new TestClass<int>();
                generator.Value = i * 4;
                myArray.SetValue(generator, i);
            }
            TestClass<int> expected = myArray.GetValue(c_MaxValue - 1) as TestClass<int>;
            IComparer<TestClass<int>> iComparableImpl = myArray.GetValue(c_MaxValue - 1) as TestClass<TestClass<int>>;
            TestClass<int> testValueNotImplTemperature = new TestClass<int>();
            int returnvalue = Array.BinarySearch<TestClass<int>>(myArray, (TestClass<int>)myArray.GetValue(c_MaxValue - 1), null);
            TestLibrary.TestFramework.LogError("012", " comparer is a null reference , " +
            "\nvalue does not implement the IComparable interface, " +
            "\nand the search encounters an element that does not \nimplement the IComparable interface.");
            retVal = false;
        }
        catch (InvalidOperationException)
        {
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("013", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
}
//create Temperature  for provding test method and test target.
public class Temperature<T> : System.Collections.Generic.IComparer<T>, IComparable
{

    // The value holder
    protected int m_value;

    public int Value
    {
        get
        {
            return m_value;
        }
        set
        {
            m_value = value;
        }
    }

    #region IComparer<T> Members

    public int Compare(T x, T y)
    {
        if (x is Temperature<T>)
        {
            Temperature<T> temp = x as Temperature<T>;

            return (y as Temperature<T>).m_value.CompareTo(temp.m_value);
        }

        return -1;
    }

    #endregion

    #region IComparable Members

    public int CompareTo(object obj)
    {
        if (obj is Temperature<T>)
        {
            Temperature<T> temp = (Temperature<T>)obj;

            return m_value.CompareTo(temp.m_value);
        }

        return -1;
    }

    #endregion
}
public class TestClass<T> : System.Collections.Generic.IComparer<T>
{

    // The value holder
    protected int m_value;

    public int Value
    {
        get
        {
            return m_value;
        }
        set
        {
            m_value = value;
        }
    }

    #region IComparer<T> Members

    public int Compare(T x, T y)
    {
        if (x is TestClass<T>)
        {
            TestClass<T> temp = x as TestClass<T>;

            return (y as TestClass<T>).m_value.CompareTo(temp.m_value);
        }

        return -1;
    }

    #endregion


}


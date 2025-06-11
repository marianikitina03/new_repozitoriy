using System.Globalization;

namespace ComplexTrStruct.UnitTests
{
    [TestFixture]
    public class ComplexTrTests
    {
        private const double Tolerance = 1e-13;
        private const double Pi = Math.PI;

        [Test]
        public void ConstructorTest()
        {
            var complex = new ComplexTr(2.5, 1.3);

            Assert.That(complex.Abs, Is.EqualTo(2.5).Within(Tolerance));
            Assert.That(complex.Arg, Is.EqualTo(1.3).Within(Tolerance));
        }

        [Test]
        public void AbsSet_NegativeValue_ArgumentException()
        {
            var complex = new ComplexTr();

            Assert.That(() => complex.Abs = -1.0, Throws.ArgumentException);
        }

        [Test]
        public void ReTest()
        {
            var testCases = new (double, double, double)[]
            {
        (2.5, 1.3, 2.5 * Math.Cos(1.3)),
        (0.0, 0.0, 0.0),
        (1.0, Pi, -1.0)
            };

            foreach (var (abs, arg, expected) in testCases)
            {
                var complex = new ComplexTr(abs, arg);
                Assert.That(complex.Re, Is.EqualTo(expected).Within(Tolerance),
                    $"Failed for Abs={abs}, Arg={arg}");
            }
        }

        [Test]
        public void ImTest()
        {
            var testCases = new (double, double, double)[]
            {
        (2.5, 1.3, 2.5 * Math.Sin(1.3)),
        (0.0, 0.0, 0.0),
        (1.0, Pi/2, 1.0)
            };

            foreach (var (abs, arg, expected) in testCases)
            {
                var complex = new ComplexTr(abs, arg);
                Assert.That(complex.Im, Is.EqualTo(expected).Within(Tolerance),
                    $"Failed for Abs={abs}, Arg={arg}");
            }
        }

        [Test]
        public void ToStringTest()
        {
            var testCases = new (double, double, string)[]
            {
        (2.5, 1.3, "2.5(cos(1.3) + i sin(1.3))"),
        (0.0, 0.0, "0"),
        (1.0, 0.3, "cos(0.3) + i sin(0.3)"),
        (1.0, -0.3, "cos(-0.3) + i sin(-0.3)"),
        (1.0, Pi, $"cos({Pi.ToString(CultureInfo.InvariantCulture)}) + i sin({Pi.ToString(CultureInfo.InvariantCulture)})")
            };

            foreach (var (abs, arg, expected) in testCases)
            {
                var complex = new ComplexTr(abs, arg);
                var actual = complex.ToString();
                var normalizedExpected = expected.Replace(",", ".");
                var normalizedActual = actual.Replace(",", ".");

                Assert.That(normalizedActual, Is.EqualTo(normalizedExpected),
                    $"Failed for Abs={abs}, Arg={arg}. Expected: {expected}, Actual: {actual}");
            }
        }
        [Test]
        public void Equals_TwoComplexNumbers_ExpectedResult()
        {
            var testCases = new (double, double, double, double, bool)[]
            {
                (2.0, 1.0, 2.0, 1.0 + 2*Pi, true),
                (2.0, 1.0, 2.0, 1.0 - 2*Pi, true),
                (2.0, 1.0, 2.0, 1.0 + 4*Pi, true),
                (2.0, 1.0, 2.0, 1.0 + 0.1, false),
                (2.0, 1.0, 2.1, 1.0, false)
            };

            foreach (var (abs1, arg1, abs2, arg2, expected) in testCases)
            {
                var complex1 = new ComplexTr(abs1, arg1);
                var complex2 = new ComplexTr(abs2, arg2);
                Assert.That(complex1.Equals(complex2), Is.EqualTo(expected),
                    $"Failed for ({abs1},{arg1}) vs ({abs2},{arg2})");
            }
        }

        [Test]
        public void Equals_WrongArgument_ArgumentException()
        {
            var complex = new ComplexTr();
            var smth = new object();

            Assert.That(() => complex.Equals(smth), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCodeTest()
        {
            var x = new ComplexTr(2.5, 1.3);
            var y = new ComplexTr(2.5, 1.3 + 2 * Pi);
            var z = new ComplexTr(3.0, 1.3);

            Assert.That(x.Equals(y), Is.True);
            Assert.That(x.Equals(z), Is.False);
        }

        [Test]
        public void ComparisonTest()
        {
            var x = new ComplexTr(2.5, 1.3);
            var y = new ComplexTr(2.5, 1.3 + 2 * Pi);
            var z = new ComplexTr(3.0, 1.3);

            Assert.That(x == y, Is.True);
            Assert.That(x != y, Is.False);
            Assert.That(x == z, Is.False);
            Assert.That(x != z, Is.True);
        }

        [Test]
        public void MultiplicationTest()
        {
            var testCases = new (double, double, double, double, double, double)[]
            {
                (2.0, 1.0, 3.0, 0.5, 6.0, 1.5),
                (1.0, Pi/2, 1.0, Pi/2, 1.0, Pi),
                (2.0, 0, 0.5, Pi, 1.0, Pi)
            };

            foreach (var (abs1, arg1, abs2, arg2, expAbs, expArg) in testCases)
            {
                var complex1 = new ComplexTr(abs1, arg1);
                var complex2 = new ComplexTr(abs2, arg2);
                var expected = new ComplexTr(expAbs, expArg);

                Assert.That(complex1 * complex2, Is.EqualTo(expected),
                    $"Failed for ({abs1},{arg1}) * ({abs2},{arg2})");
            }
        }

        [Test]
        public void DivisionTest()
        {
            var testCases = new (double, double, double, double, double, double)[]
            {
                (2.0, 1.0, 0.5, 0.5, 4.0, 0.5),
                (1.0, Pi/2, 1.0, Pi/4, 1.0, Pi/4),
                (4.0, Pi, 2.0, Pi/2, 2.0, Pi/2)
            };

            foreach (var (abs1, arg1, abs2, arg2, expAbs, expArg) in testCases)
            {
                var complex1 = new ComplexTr(abs1, arg1);
                var complex2 = new ComplexTr(abs2, arg2);
                var expected = new ComplexTr(expAbs, expArg);

                Assert.That(complex1 / complex2, Is.EqualTo(expected),
                    $"Failed for ({abs1},{arg1}) / ({abs2},{arg2})");
            }
        }

        [Test]
        public void Division_ByZero_DivideByZeroException()
        {
            var complex1 = new ComplexTr(1.0, 0);
            var complex2 = new ComplexTr(0, 0);

            Assert.That(() => complex1 / complex2, Throws.TypeOf<DivideByZeroException>());
        }
    }
}
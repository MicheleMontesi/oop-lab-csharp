namespace ExtensionMethods
{
    using System;

    /// <inheritdoc cref="IComplex"/>
    public class Complex : IComplex
    {
        private const double Tolerance = 1E-7;
        private readonly double re;
        private readonly double im;

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="re">the real part.</param>
        /// <param name="im">the imaginary part.</param>
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        /// <inheritdoc cref="IComplex.Real"/>
        public double Real => re;

        /// <inheritdoc cref="IComplex.Imaginary"/>
        public double Imaginary => im;

        /// <inheritdoc cref="IComplex.Modulus"/>
        public double Modulus => Math.Sqrt(re * re + im * im);

        /// <inheritdoc cref="IComplex.Phase"/>
        public double Phase => Math.Atan2(im, re);

        /// <inheritdoc cref="IComplex.ToString"/>
        public override string ToString() => $"{re} {(im >= 0 ? "+" : "-")} i{Math.Abs(im)}";

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(IComplex other)
        {
            return other != null
                   && Math.Abs(Imaginary - other.Imaginary) < Tolerance
                   && Math.Abs(Real - other.Real) < Tolerance;
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            if (obj is IComplex)
            {
                return Equals(obj as IComplex);
            }

            return false;
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            // TODO improve
            return HashCode.Combine(re, im);
        }
    }
}

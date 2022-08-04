using System;
using System.Runtime.Serialization;

namespace Microsoft.Xna.Framework
{
    /// <summary>
    /// Describes a 2D-quad.
    /// </summary>
    [DataContract]
    public struct Quad : IEquatable<Quad>
    {
        #region Public Fields
        /// <summary>
        /// The coordinates of the top-left corner of this <see cref="Quad"/>.
        /// </summary>
        [DataMember]
        public Vector2 TopLeft;

        /// <summary>
        /// The coordinates of the top-right corner of this <see cref="Quad"/>.
        /// </summary>
        [DataMember]
        public Vector2 TopRight;

        /// <summary>
        /// The coordinates of the bottom-right corner of this <see cref="Quad"/>.
        /// </summary>
        [DataMember]
        public Vector2 BottomRight;

        /// <summary>
        /// The coordinates of the bottom-left corner of this <see cref="Quad"/>.
        /// </summary>
        [DataMember]
        public Vector2 BottomLeft;
        #endregion

        #region Public Properties
        /// <summary>
        /// The minimum bounds of this <see cref="Quad"/>.
        /// </summary>
        public Rectangle Bounds
        {
            get
            {
                var minX = (int)MathF.Min(TopLeft.X, BottomLeft.X);
                var maxX = (int)MathF.Max(TopRight.X, BottomRight.X);

                var minY = (int)MathF.Min(BottomLeft.Y, BottomRight.Y);
                var maxY = (int)MathF.Max(TopLeft.Y, TopRight.Y);

                return new(minX, minY, maxX - minX, maxY - minY);
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new instance of <see cref="Quad"/> struct, with the specified
        /// position, width, and height.
        /// </summary>
        /// <param name="x">The x coordinate of the top-left corner of the created <see cref="Quad"/>.</param>
        /// <param name="y">The y coordinate of the top-left corner of the created <see cref="Quad"/>.</param>
        /// <param name="width">The width of the created <see cref="Quad"/>.</param>
        /// <param name="height">The height of the created <see cref="Quad"/>.</param>
        public Quad(float x, float y, float width, float height)
        {
            TopLeft = new(x, y);
            TopRight = new(x + width, y);
            BottomRight = new(x + width, y + height);
            BottomLeft = new(x, y + height);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Quad"/> struct, with the specified
        /// corner coordinates.
        /// </summary>
        /// <param name="topLeft">The coordinates of the top-left corner of the created <see cref="Quad"/>.</param>
        /// <param name="topRight">The coordinates of the top-right corner of the created <see cref="Quad"/>.</param>
        /// <param name="bottomRight">The coordinates of the bottom-right corner of the created <see cref="Quad"/>.</param>
        /// <param name="bottomLeft">The coordinates of the bottom-left corner of the created <see cref="Quad"/>.</param>
        public Quad(Vector2 topLeft, Vector2 topRight, Vector2 bottomRight, Vector2 bottomLeft)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomRight = bottomRight;
            BottomLeft = bottomLeft;
        }
        #endregion

        #region Operators
        /// <summary>
        /// Compares whether two <see cref="Quad"/> instances are equal.
        /// </summary>
        /// <param name="a"><see cref="Quad"/> instance on the left of the equal sign.</param>
        /// <param name="b"><see cref="Quad"/> instance on the right of the equal sign.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public static bool operator ==(Quad a, Quad b)
        {
            return ((a.TopLeft == b.TopLeft) && (a.TopRight == b.TopRight) && (a.BottomRight == b.BottomRight) && (a.BottomLeft == b.BottomLeft));
        }

        /// <summary>
        /// Compares whether two <see cref="Quad"/> instances are not equal.
        /// </summary>
        /// <param name="a"><see cref="Quad"/> instance on the left of the not equal sign.</param>
        /// <param name="b"><see cref="Quad"/> instance on the right of the not equal sign.</param>
        /// <returns><c>true</c> if the instances are not equal; <c>false</c> otherwise.</returns>
        public static bool operator !=(Quad a, Quad b)
        {
            return !(a == b);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            return obj is Quad other && this == other;
        }

        /// <summary>
        /// Compares whether current instance is equal to specified <see cref="Quad"/>.
        /// </summary>
        /// <param name="other">The <see cref="Quad"/> to compare.</param>
        /// <returns><c>true</c> if the instances are equal; <c>false</c> otherwise.</returns>
        public bool Equals(Quad other)
        {
            return this == other;
        }

        /// <summary>
        /// Gets the hash code of this <see cref="Quad"/>.
        /// </summary>
        /// <returns>Hash code of this <see cref="Quad"/>.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(TopLeft, TopRight, BottomRight, BottomLeft);
        }

        /// <summary>
        /// Returns a <see cref="string"/> representation of this <see cref="Quad"/>.
        /// </summary>
        /// <returns><see cref="string"/> representation of this <see cref="Quad"/>.</returns>
        public override string ToString()
        {
            return "{TopLeft:" + TopLeft + " TopRight:" + TopRight + " BottomRight:" + BottomRight + " BottomLeft:" + BottomLeft + "}";
        }

        /// <summary>
        /// Deconstruction method for <see cref="Quad"/>.
        /// </summary>
        /// <param name="topLeft"></param>
        /// <param name="topRight"></param>
        /// <param name="bottomRight"></param>
        /// <param name="bottomLeft"></param>
        public void Deconstruct(out Vector2 topLeft, out Vector2 topRight, out Vector2 bottomRight, out Vector2 bottomLeft)
        {
            topLeft = TopLeft;
            topRight = TopRight;
            bottomRight = BottomRight;
            bottomLeft = BottomLeft;
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;

namespace GameLogic.Strategies
{
    public static class DistanceHelper
    {
        private static Vector[] RotateVector = new Vector[] {
            new Vector(1, 0),
            new Vector(1, 1),
            new Vector(0, 1),
            new Vector(-1, 1),
            new Vector(-1, 0),
            new Vector(-1, -1),
            new Vector(0, -1),
            new Vector(1, -1)
        };

        public const double Pi_quarter = Math.PI / 4;
        public const double Pi_quarter_minus = - 1 * Math.PI / 4;
        public const double Pi_quarter_third = Math.PI * 3 / 4;
        public const double Pi_quarter_third_minus = -1 * Math.PI * 3 / 4;

        public static int GetDistanceSquared(IUnit u1, IUnit u2)
        {
            var diff1 = u2.X - u1.X;
            var diff2 = u2.Y - u1.Y;

            return diff1 * diff1 + diff2 * diff2;
        }

        public static Vector GetMoveTowardsPoint(IUnit unit, int x, int y)
        {
            var angle = Math.Atan2(y - unit.Y, x - unit.X);
            int x_diff = 0;
            int y_diff = 0;

            if (angle >= Pi_quarter_minus && angle <= Pi_quarter)
            {
                x_diff = 1;
            }

            if(angle >= Pi_quarter_third || angle <= Pi_quarter_third_minus)
            {
                x_diff = -1;
            }

            if (angle >= Pi_quarter && angle <= Pi_quarter_third)
            {
                y_diff = 1;
            }

            if (angle <= Pi_quarter_minus && angle >= Pi_quarter_third_minus)
            {
                y_diff = -1;
            }


            return new Vector(x_diff, y_diff);
        }

        public static IEnumerable<Vector> GetAdjancedDirectionVectors(Vector binaryMovementVector)
        {
            var vectorIndex = Array.FindIndex(RotateVector, v => v.X == binaryMovementVector.X && v.Y == binaryMovementVector.Y);

            var counterClockWiseIndex = (vectorIndex + 1) % RotateVector.Length;
            yield return RotateVector[counterClockWiseIndex];

            var clockWiseIndex = vectorIndex - 1;
            if (clockWiseIndex < 0)
            {
                clockWiseIndex = clockWiseIndex + RotateVector.Length;
            }

            yield return RotateVector[clockWiseIndex];

            yield return RotateVector[(vectorIndex + 2) % RotateVector.Length];

            clockWiseIndex = vectorIndex - 2;
            if (clockWiseIndex < 0)
            {
                clockWiseIndex = clockWiseIndex + RotateVector.Length;
            }

            yield return RotateVector[clockWiseIndex];
        }
    }
}

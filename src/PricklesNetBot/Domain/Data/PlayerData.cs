using PricklesNetBot.Domain.IO;
using System;

namespace PricklesNetBot.Domain.Data
{
    public class PlayerData
    {
        private readonly InputParameters input;

        public double XVelocity
        {
            get
            {
                switch (input.CurrentPlayer)
                {
                    case PlayerType.Blue1:
                        return input.Blue1XVelocity;
                    case PlayerType.Orange1:
                        return input.Orange1XVelocity;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public double YVelocity
        {
            get
            {
                switch (input.CurrentPlayer)
                {
                    case PlayerType.Blue1:
                        return input.Blue1YVelocity;
                    case PlayerType.Orange1:
                        return input.Orange1YVelocity;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public double ZVelocity
        {
            get
            {
                switch (input.CurrentPlayer)
                {
                    case PlayerType.Blue1:
                        return input.Blue1ZVelocity;
                    case PlayerType.Orange1:
                        return input.Orange1ZVelocity;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public double XPosition
        {
            get
            {
                switch (input.CurrentPlayer)
                {
                    case PlayerType.Blue1:
                        return input.Blue1XPosition;
                    case PlayerType.Orange1:
                        return input.Orange1XPosition;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public double YPosition
        {
            get
            {
                switch (input.CurrentPlayer)
                {
                    case PlayerType.Blue1:
                        return input.Blue1YPosition;
                    case PlayerType.Orange1:
                        return input.Orange1YPosition;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public double ZPosition
        {
            get
            {
                switch (input.CurrentPlayer)
                {
                    case PlayerType.Blue1:
                        return input.Blue1ZPosition;
                    case PlayerType.Orange1:
                        return input.Orange1ZPosition;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public double Pitch
        {
            get
            {
                switch (input.CurrentPlayer)
                {
                    case PlayerType.Blue1:
                        return input.Blue1Pitch;
                    case PlayerType.Orange1:
                        return input.Orange1Pitch;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public double Yaw
        {
            get
            {
                switch (input.CurrentPlayer)
                {
                    case PlayerType.Blue1:
                        return input.Blue1Yaw;
                    case PlayerType.Orange1:
                        return input.Orange1Yaw;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public double Roll
        {
            get
            {
                switch (input.CurrentPlayer)
                {
                    case PlayerType.Blue1:
                        return input.Blue1Roll;
                    case PlayerType.Orange1:
                        return input.Orange1Roll;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public double Boost
        {
            get
            {
                switch (input.CurrentPlayer)
                {
                    case PlayerType.Blue1:
                        return input.Blue1Boost;
                    case PlayerType.Orange1:
                        return input.Orange1Boost;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public PlayerData(InputParameters input)
        {
            this.input = input;
        }
    }
}

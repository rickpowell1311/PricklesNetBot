using System;

namespace PricklesNetBot.Domain.Constants
{
    public static class PlayerMovement
    {
        public static double TurnSharpAngleCutoffRadians = Math.PI / 8;

        public static double SecondFlipDelay = 100;

        public static double LowerAxisDeadzone = 15200;

        public static double UpperAxisDeadzone = 17000;
    }
}

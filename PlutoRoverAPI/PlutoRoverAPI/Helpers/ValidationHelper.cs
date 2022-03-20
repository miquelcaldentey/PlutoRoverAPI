using PlutoRoverAPI.Models.Enums;

namespace PlutoRoverAPI.Helpers
{
    public static class ValidationHelper
    {
        public static bool AreCommandsOk(string movements)
        {
            if (string.IsNullOrWhiteSpace(movements))
                return false;

            return movements.All(move => IsValid(move));
        }

        private static bool IsValid(char move)
        {
            return Enum.TryParse(typeof(Commands), move.ToString(), out _);
        }
    }
}

using System.Text;

namespace CleanArc.Domain.Shared.Exceptions;

public static class StringExtension
{
    public static string ToBase64(this string text) => Convert.ToBase64String(Encoding.ASCII.GetBytes(text));
}
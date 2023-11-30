
using PostSharp.Aspects;

namespace AspectOrientedProgramming.Aspect
{
    [Serializable]
    public class LogAspect :OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine($"Metod başladı: {args.Method.Name}");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine($"Metod bitti: {args.Method.Name}");
        }
    }
}
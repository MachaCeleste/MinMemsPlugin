using HarmonyLib;
using MinMemsPlugin;
using System.Collections.Generic;
using System.Reflection.Emit;
using Util;

[HarmonyPatch]
public class LibraryPatch
{
    [HarmonyPatch(typeof(Library), "Configure")]
    class ConfigurePatch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            foreach (var instruction in instructions)
            {
                if (Networking.IsSinglePlayer() && instruction.opcode == OpCodes.Ldc_I4 && (int)instruction.operand == 2)
                    instruction.operand = Plugin.minMems.Value;
                yield return instruction;
            }
        }
    }
}
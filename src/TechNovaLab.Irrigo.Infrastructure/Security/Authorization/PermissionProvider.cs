namespace TechNovaLab.Irrigo.Infrastructure.Security.Authorization
{
    internal sealed class PermissionProvider
    {
        public Task<HashSet<string>> GetForUserIdAsync(Guid userId)
        {
            // TODO: obtener los permisos de bd aquí.
            HashSet<string> permissionsSet = ["users:access"];

            return Task.FromResult(permissionsSet);
        }
    }
}

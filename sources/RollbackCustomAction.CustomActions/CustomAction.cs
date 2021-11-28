// WiX Toolset Pills 15mg
// Copyright (C) 2019-2021 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using Microsoft.Deployment.WindowsInstaller;

namespace RollbackCustomAction.CustomActions
{
    public static class CustomActions
    {
        [CustomAction]
        public static ActionResult DoSomething(Session session)
        {
            session.Log("----> [DoSomething] This custom action does something.");

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult DoSomethingRollback(Session session)
        {
            session.Log("----> [DoSomethingRollback] This custom action rolls back what the previous one did.");

            return ActionResult.Success;
        }

        [CustomAction]
        public static ActionResult Crush(Session session)
        {
            session.Log("----> [Crush] This custom action returns failure.");

            return ActionResult.Failure;
        }
    }
}
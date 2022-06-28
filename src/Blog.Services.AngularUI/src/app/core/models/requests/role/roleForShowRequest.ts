export class RoleForShowRequest {
  id: string;
  roleName: string;

  constructor(id: string, roleName: string) {
    this.id = id;
    this.roleName = roleName;
  }
}

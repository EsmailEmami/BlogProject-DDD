export class UpdateUserRequest {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  roles: string[];

  constructor(id: string, firstName: string, lastName: string, email: string, roles: string[]) {
    this.id = id;
    this.firstName = firstName;
    this.lastName = lastName;
    this.email = email;
    this.roles = roles;
  }

  public fullName(): string {
    return this.firstName + ' ' + this.lastName;
  }
}

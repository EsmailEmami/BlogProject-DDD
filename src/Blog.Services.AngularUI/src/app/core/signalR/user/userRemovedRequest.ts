export class UserRemovedRequest {
  userId: string;
  fullName: string;

  constructor(userId: string, fullName: string) {
    this.userId = userId;
    this.fullName = fullName;
  }
}

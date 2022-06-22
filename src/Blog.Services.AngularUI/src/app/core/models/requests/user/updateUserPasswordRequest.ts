export class UpdateUserPasswordRequest {
  userId: string;
  currentPassword: string;
  newPassword: string;
  confirmNewPassword: string;

  constructor(userId: string, currentPassword: string, newPassword: string, confirmNewPassword: string) {
    this.userId = userId;
    this.currentPassword = currentPassword;
    this.newPassword = newPassword;
    this.confirmNewPassword = confirmNewPassword;
  }
}

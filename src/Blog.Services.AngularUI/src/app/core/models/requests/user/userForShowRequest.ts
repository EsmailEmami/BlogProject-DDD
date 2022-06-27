export class UserForShowRequest {
  userId:string;
  fullName:string;
  email:string;


  constructor(userId: string, fullName: string, email: string) {
    this.userId = userId;
    this.fullName = fullName;
    this.email = email;
  }
}

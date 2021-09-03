export interface User{    
    id: string;
    username: string;
    firstName: string;
    lastName: string;
    bearerToken?: string;
    isAuthenticated:boolean;    
}
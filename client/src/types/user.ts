export type User = {
    id: string;
    email: string;
    displayName: string;
    token: string;
    imageUrl?: string;
}

export type LoginCredentials = {
    email: string;
    password: string;
}

export type RegisterCredentials = {
    email: string;
    password: string;
    displayName: string;
}
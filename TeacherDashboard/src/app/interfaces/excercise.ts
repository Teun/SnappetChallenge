export interface Excercise {
  id: number,
  submissions: number,
  difficulty: string,
  subject: string,
  objective: string,
  progress: Array<number>
}

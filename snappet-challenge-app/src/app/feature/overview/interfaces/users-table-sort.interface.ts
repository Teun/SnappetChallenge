export interface UsersTableSorter {
  id: SortStatuses;
  name: SortStatuses;
  correctAnswers: SortStatuses;
}

export type SortStatuses = 'desc' | 'default' | 'asc';

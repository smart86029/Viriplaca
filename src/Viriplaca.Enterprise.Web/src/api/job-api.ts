import type { Guid } from '@/models/guid';
import type { OptionResult } from '@/models/option-result';
import type { PageResult } from '@/models/page';
import httpClient from './http-client';

export interface Job {
  id: Guid;
  title: string;
  isEnabled: boolean;
  employeeCount: number;
}

export default {
  getOptions: () => httpClient.get<OptionResult<Guid>[]>('/Jobs/Options'),
  getList: (isEnabled?: boolean) => {
    return httpClient.get<PageResult<Job>>('/Jobs', {
      params: { isEnabled },
    });
  },
};

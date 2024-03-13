import { create, edit } from './props';

export default [
  {
    path: 'organization',
    name: 'organization',
    redirect: { name: 'employee.list' },
    children: [
      {
        path: 'employees',
        name: 'employee.list',
        redirect: { name: '' },
        children: [
          {
            path: '',
            component: () => import('../views/organization/EmployeeList.vue'),
          },
          {
            path: 'create',
            name: 'employee.create',
            component: () => import('../views/organization/EmployeeForm.vue'),
            props: create,
          },
          {
            path: ':id',
            name: 'employee.edit',
            component: () => import('../views/organization/EmployeeForm.vue'),
            props: edit,
          },
        ],
      },
      {
        path: 'departments',
        name: 'department.list',
        redirect: { name: '' },
        children: [
          {
            path: '',
            component: () => import('../views/organization/DepartmentList.vue'),
          },
          {
            path: 'create',
            name: 'department.create',
            component: () => import('../views/organization/DepartmentForm.vue'),
            props: create,
          },
          {
            path: ':id',
            name: 'department.edit',
            component: () => import('../views/organization/DepartmentForm.vue'),
            props: edit,
          },
        ],
      },
      {
        path: 'jobs',
        name: 'job.list',
        redirect: { name: '' },
        children: [
          {
            path: '',
            component: () => import('../views/organization/JobList.vue'),
          },
          {
            path: 'create',
            name: 'job.create',
            component: () => import('../views/organization/JobForm.vue'),
            props: create,
          },
          {
            path: ':id',
            name: 'job.edit',
            component: () => import('../views/organization/JobForm.vue'),
            props: edit,
          },
        ],
      },
    ],
  },
];

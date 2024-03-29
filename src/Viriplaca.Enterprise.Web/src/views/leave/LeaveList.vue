<template>
  <div class="toolbar">
    <el-form :inline="true" :model="query">
      <el-form-item :label="$t('common.time')">
        <DateTimeRangePicker />
      </el-form-item>
      <el-form-item :label="$t('common.status')">
        <SelectEnum
          v-model="query.approvalStatus"
          :enum="ApprovalStatus"
          localeKey="status.approval"
        />
      </el-form-item>
    </el-form>
    <FlexDivider />
    <ButtonCreate route="leave.apply" :text="$t('operation.apply')" />
  </div>
  <el-table v-loading="loading" :data="result.items">
    <el-table-column prop="type" :label="$t('common.type')">
      <template #default="{ row }">
        {{ types.get(row.type) }}
      </template>
    </el-table-column>
    <el-table-column
      prop="startedAt"
      :label="$t('common.startTime')"
      :formatter="dateTimeFormatter"
    />
    <el-table-column
      prop="endedAt"
      :label="$t('common.endTime')"
      :formatter="dateTimeFormatter"
    />
    <el-table-column prop="duration" :label="$t('common.duration')">
      <template #default="{ row }">
        {{ durationFormatter(row.startedAt, row.endedAt) }}
      </template>
    </el-table-column>
    <el-table-column prop="approvalStatus" :label="$t('common.status')">
      <template #default="{ row }">
        {{ $t(`status.approval.${row.approvalStatus}`) }}
      </template>
    </el-table-column>
    <el-table-column :label="$t('common.operations')">
      <template #default="{ row }">
        <!-- <TextLink
          :to="{ name: 'operator.edit', params: { id: row.id } }"
          :text="$t('operation.edit')"
        /> -->
      </template>
    </el-table-column>
  </el-table>
</template>

<script setup lang="ts">
import leaveApi, { type GetLeavesQuery, type Leave } from '@/api/leave-api';
import { ApprovalStatus } from '@/models/approval-status';
import { defaultQuery, defaultResult, type PageResult } from '@/models/page';
import {
  dateTimeFormatter,
  defaultRange,
  durationFormatter,
} from '@/plugins/dayjs';

const loading = ref(false);
const types = new Map<number, string>();
const range = ref(defaultRange());
const query: GetLeavesQuery = reactive({
  approvalStatus: undefined,
  ...defaultQuery,
});
const result: PageResult<Leave> = reactive(defaultResult());

leaveApi
  .getTypes()
  .then((x) => x.data.forEach((y) => types.set(y.value, y.name)));

watch(
  [query, range],
  ([query, [startedAt, endedAt]]) => {
    loading.value = true;
    leaveApi
      .getList(Object.assign(query, { startedAt, endedAt }))
      .then((x) => Object.assign(result, x.data))
      .finally(() => (loading.value = false));
  },
  { immediate: true },
);
</script>

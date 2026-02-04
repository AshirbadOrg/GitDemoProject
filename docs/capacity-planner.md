# Capacity Planner

A lightweight, reusable capacity planning template for team resource allocation and sprint planning.

## Overview

This capacity planner helps teams track resource availability, allocations, and remaining capacity across sprints/weeks. It's designed to be simple, flexible, and repo-agnostic.

## Capacity Planning Template

### Sprint/Week: [Week of 2026-02-03 to 2026-02-07]

| Team Member | Role | Availability (%) | Project/Epic | Planned Allocation (hrs) | Sprint/Week | Notes | Total Allocated |
|-------------|------|------------------|--------------|--------------------------|-------------|-------|-----------------|
| Sarah Chen | Senior Developer | 100% (40h) | ToyStore Frontend | 20h | Week 6 | Angular 20 upgrade | 35h |
| Sarah Chen | Senior Developer | 100% (40h) | Auth System Refactor | 15h | Week 6 | JWT improvements | 35h |
| Mike Rodriguez | Backend Developer | 80% (32h) | ToyStore API | 24h | Week 6 | New endpoints | 30h |
| Mike Rodriguez | Backend Developer | 80% (32h) | Database Optimization | 6h | Week 6 | Query tuning | 30h |
| Priya Patel | QA Engineer | 100% (40h) | Testing - API | 16h | Week 6 | Integration tests | 38h |
| Priya Patel | QA Engineer | 100% (40h) | Testing - Frontend | 16h | Week 6 | E2E tests | 38h |
| Priya Patel | QA Engineer | 100% (40h) | Bug Fixes | 6h | Week 6 | Critical issues | 38h |
| Alex Thompson | DevOps Engineer | 75% (30h) | CI/CD Pipeline | 18h | Week 6 | Deploy automation | 28h |
| Alex Thompson | DevOps Engineer | 75% (30h) | Monitoring Setup | 10h | Week 6 | Application metrics | 28h |
| Jordan Lee | UX Designer | 100% (40h) | Product Redesign | 24h | Week 6 | Mobile responsiveness | 32h |
| Jordan Lee | UX Designer | 100% (40h) | User Research | 8h | Week 6 | Customer feedback | 32h |
| Emily Davis | Junior Developer | 100% (40h) | Documentation | 12h | Week 6 | API docs update | 36h |
| Emily Davis | Junior Developer | 100% (40h) | Minor Features | 16h | Week 6 | UI enhancements | 36h |
| Emily Davis | Junior Developer | 100% (40h) | Code Reviews | 8h | Week 6 | Learning | 36h |

### Capacity Summary

| Team Member | Total Hours Available | Total Allocated | Remaining Capacity | Utilization |
|-------------|----------------------|-----------------|-------------------|-------------|
| Sarah Chen | 40h | 35h | 5h | 87.5% |
| Mike Rodriguez | 32h | 30h | 2h | 93.75% |
| Priya Patel | 40h | 38h | 2h | 95% |
| Alex Thompson | 30h | 28h | 2h | 93.3% |
| Jordan Lee | 40h | 32h | 8h | 80% |
| Emily Davis | 40h | 36h | 4h | 90% |
| **TEAM TOTAL** | **222h** | **199h** | **23h** | **89.6%** |

## Usage Instructions

### 1. Initial Setup

1. Copy this template for each sprint/week
2. Update the Sprint/Week header with the date range
3. List all team members with their roles

### 2. Setting Availability

**Availability (%)** represents the percentage of a standard work week available for project work:

- **100% = 40 hours**: Full-time, no meetings, no PTO
- **80-90%**: Normal availability (accounting for meetings, admin work)
- **50-70%**: Partial availability (PTO, other commitments)
- **0-30%**: Very limited availability (training, conferences)

**Example calculations:**
- Developer with 20% time in meetings: 80% × 40h = 32h available
- Developer on 2-day PTO: 60% × 40h = 24h available
- Part-time contractor (20h/week): 50% × 40h = 20h available

### 3. Planning Allocations

1. **Break down projects/epics** into time estimates
2. **Allocate hours** to each team member based on:
   - Their expertise and role
   - Task dependencies
   - Priority and deadlines
3. **Add multiple rows** for a team member if working on multiple projects
4. **Include buffer time** for unexpected issues (typically 10-20%)

### 4. Weekly Updates

**At sprint planning:**
1. Review last week's plan vs. actual
2. Update availability for upcoming week (PTO, holidays, etc.)
3. Allocate work for the new sprint
4. Ensure no one is over-allocated (>100% utilization)

**During the week:**
1. Track actual time spent vs. planned
2. Adjust allocations if priorities change
3. Update notes with blockers or changes

**At sprint retro:**
1. Compare planned vs. actual capacity used
2. Identify patterns (consistent over/under-allocation)
3. Improve estimates for next sprint

### 5. Calculating Remaining Capacity

**Formula:**
```
Remaining Capacity = Total Available Hours - Total Allocated Hours
Utilization % = (Total Allocated / Total Available) × 100
```

**Interpretation:**
- **< 70%**: Under-allocated, can take on more work
- **70-85%**: Healthy allocation with buffer for unknowns
- **85-95%**: Fully allocated, limited flexibility
- **> 95%**: Over-allocated, risk of burnout or missed deadlines

### 6. Best Practices

✅ **Do:**
- Update weekly at the start of each sprint
- Include buffer time (10-20%) for unexpected work
- Account for meetings, admin work, and overhead
- Track PTO and holidays in advance
- Review and adjust based on actual time spent

❌ **Don't:**
- Allocate team members at 100% utilization (no buffer)
- Forget to account for meetings and non-project work
- Leave estimates unchanged when scope changes
- Ignore patterns of over/under-estimation

## Notes Section Guidelines

Use the **Notes** column to track:
- **Blockers**: "Waiting on API design approval"
- **Dependencies**: "Blocked by database migration"
- **Risks**: "Estimate uncertain, complex task"
- **Context**: "First time working with this tech"
- **Changes**: "Scope reduced after planning"

## Customization

This template can be adapted for:
- **Different time periods**: Daily, bi-weekly, monthly
- **Additional columns**: Priority, Task ID, Story Points
- **Different units**: Story points instead of hours
- **Multiple teams**: Create separate sections or files
- **Project-specific metrics**: Add custom fields as needed

## CSV Template

A CSV version of this template is available at `/templates/capacity-planner.csv` for easy import into spreadsheet applications like Excel, Google Sheets, or Numbers.

## Example Scenarios

### Scenario 1: Developer with PTO
```
Team Member: Mike Rodriguez
Role: Backend Developer
Availability: 60% (24h) - Out Monday & Tuesday
Project: API Development
Planned Allocation: 20h
Notes: 3-day work week
```

### Scenario 2: Multiple Small Tasks
```
Team Member: Emily Davis
Role: Junior Developer
Rows:
  - Documentation (12h) - API docs update
  - Minor Features (16h) - UI enhancements
  - Code Reviews (8h) - Learning opportunity
Total: 36h / 40h = 90% utilization
```

### Scenario 3: Over-allocation (to avoid)
```
Team Member: Sarah Chen
Total Available: 40h
Allocated: 48h ❌ OVER-ALLOCATED
Action: Reduce scope or defer work to next sprint
```

## Questions & Support

For questions about using this capacity planner:
1. Review the examples above
2. Check the best practices section
3. Adapt the template to your team's workflow
4. Start simple and add complexity as needed

---

**Template Version**: 1.0  
**Last Updated**: 2026-02-04  
**Maintained by**: Ashirbad_SampleProject Team

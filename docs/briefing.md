# Briefing — taskflow Secure CI/CD Pipeline

> Fictional client (lab project). Follows the SOC 2 readiness engagement.

## 1. The client

- **Product:** taskflow — a project-management SaaS (B2B), deployed to Kubernetes.
- **Team:** small startup, a few developers, deploying frequently.

## 2. Why now

- taskflow is pursuing SOC 2. The auditor asked for evidence that changes to
  production are **authorized, tested and approved** before they ship (control CC8.1).
- Today, code is reviewed informally and deployed by hand. There is no automated
  gate and no record an auditor could rely on.

## 3. Goal of this engagement

Build a CI/CD pipeline that is both a **security control** and an **evidence
generator**:

- Every change is reviewed and must pass automated security checks before merge.
- Code, dependencies, infrastructure-as-code, secrets and the container image are
  scanned.
- Only signed images are allowed to run in the cluster.
- Deployment uses short-lived credentials, not stored secrets.
- Each step produces evidence mapped to a SOC 2 control.

## 4. Scope

- One application, from commit to deployment on the cluster.
- Lab environment: a local kind cluster, GitHub Actions, the taskflow / Agendai API.

## 5. SOC 2 controls this supports

| Pipeline step | SOC 2 control |
| --- | --- |
| PR review + automated scans before merge | CC8.1 (change management) |
| Secret scanning (Gitleaks) | CC6.7 (credential protection) |
| Image vulnerability scan (Trivy) | CC7.1 (vulnerability detection) |
| Separation of author and approver | CC8.1 |
